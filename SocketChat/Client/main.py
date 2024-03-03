import socket
import threading
import json

class ChatClient:
    def __init__(self, host, port, nickname):
        self.host = host
        self.port = port
        self.port_udp = port
        self.nickname = nickname
        self.tcp_connection = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        self.tcp_connection.connect((self.host, self.port))

        self._receive_thread = None
        self._send_thread = None

    def receive_messages(self):
        while True:
            try:
                message = self.tcp_connection.recv(2048).decode('utf-8')
                print(message)
            except ConnectionAbortedError as e:
                print("Finished receiving messages.")
                break
            except Exception as e:
                print(f"Error receiving message: {e}")
                break

    def send_message(self):
        while True:
            try:
                message = input()
                if message.lower() == 'exit':
                    self.tcp_connection.sendall("exit")
                    self.tcp_connection.close()
                    print("Finished sending messages.")
                    break

                if len(message) > 2000:
                    print("Too long message.")
                    continue

                if message.startswith('T'):
                    message = message[1:]
                    self.tcp_connection.sendall(f"{self.nickname}: {message}".encode('utf-8'))

                if message.startswith('U'):
                    message = message[1:]
                    message = f"{self.nickname}: {message}"
                    address, port = self.tcp_connection.getsockname()
                    data = {
                        "data": message,
                        "port": port,
                        "address": address
                    }

                    payload = json.dumps(data)

                    udp_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
                    udp_socket.sendto(payload.encode('utf-8'), (self.host, self.port_udp))
                    udp_socket.close()

            except Exception as e:
                print(f"Error sending message: {e}")
                break

    def start(self):
        self._receive_thread = threading.Thread(target=self.receive_messages)
        self._send_thread = threading.Thread(target=self.send_message)

        self._receive_thread.start()
        self._send_thread.start()


if __name__ == "__main__":
    HOST = 'localhost'
    PORT = 5555
    nick = input("Enter your nickname: ")

    if len(nick) > 40:
        print("Failed to start program: too long nick.")
        exit(1)

    client = ChatClient(HOST, PORT, nick)
    client.start()
