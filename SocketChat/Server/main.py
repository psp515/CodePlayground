import socket
import threading
import json

class ChatServer:
    def __init__(self, host, port):
        self.host = host
        self.port = port
        self.port_udp = port
        self.clients = []
        self.server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        self.server_socket.bind((self.host, self.port))
        self.server_socket.listen(5)

        self.udp_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
        self.udp_socket.bind((self.host, self.port_udp))

        print(f"Server working on {self.host}:{self.port}")

    def handle_client(self, client_socket, client_address):
        while True:
            try:
                message = client_socket.recv(1024).decode('utf-8')
                if message == "exit" or not message:
                    self.remove_client(client_socket)
                    break
                print(f"Received message from {client_address}: {message}")
                self.broadcast(message, client_socket)
            except ConnectionResetError as e:
                print(f"Client disconnected: {client_address}")
                self.remove_client(client_socket)
                break
            except Exception as e:
                print(f"Error handling client {client_address}: {e}")
                self.remove_client(client_socket)
                break

    def broadcast(self, message, sender_socket):
        for client in self.clients:
            if client != sender_socket:
                try:
                    client.sendall(message.encode('utf-8'))
                except Exception as e:
                    print(f"Error broadcasting message to a client: {e}")
                    self.remove_client(client)

    def remove_client(self, client_socket):
        if client_socket in self.clients:
            self.clients.remove(client_socket)
            client_socket.close()

    def start(self):
        udp_thread = threading.Thread(target=self.start_udp)
        udp_thread.start()

        while True:
            client_socket, client_address = self.server_socket.accept()
            print(f"Client connected from {client_address}")
            client_thread = threading.Thread(target=self.handle_client, args=(client_socket, client_address))
            client_thread.daemon = True
            client_thread.start()
            self.clients.append(client_socket)

    def start_udp(self):
        while True:
            try:
                message = self.udp_socket.recv(1024).decode('utf-8')

                print(f"Received message udp message {message}")

                data = json.loads(message)
                message = data["data"]
                tcp_port = data["port"]
                tcp_address = data["address"]

                for client in self.clients:
                    address, port = client.getpeername()
                    if address != tcp_address or port != tcp_port:
                        try:
                            client.sendall(message.encode('ascii'))
                        except Exception as e:
                            print(f"Error broadcasting message to a client: {e}")
                            self.remove_client(client)

            except Exception as e:
                print(f"Error broadcasting UDP message to a clients: {e}")


if __name__ == "__main__":
    HOST = 'localhost'
    PORT = 5555
    server = ChatServer(HOST, PORT)
    server.start()
