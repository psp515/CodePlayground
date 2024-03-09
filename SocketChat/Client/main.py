import socket
import threading
import json
import struct


class ChatClient:
    def __init__(self, host, port, m_host, m_port, nickname):
        self.m_host = m_host
        self.m_port = m_port
        self.host = host
        self.port = port
        self.port_udp = port
        self.nickname = nickname
        self.tcp_connection = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        self.tcp_connection.connect((self.host, self.port))
        self._receive_thread = None
        self._send_thread = None
        self._receive_m_thread = None

        try:
            m_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM, socket.IPPROTO_UDP)
            m_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
            m_socket.bind(('', self.m_port))
            mreq = struct.pack('4sL', socket.inet_aton(self.m_host), socket.INADDR_ANY)
            m_socket.setsockopt(socket.IPPROTO_IP, socket.IP_ADD_MEMBERSHIP, mreq)

            self.m_socket = m_socket
        except Exception as e:
            self.m_socket = None
            print("Exception when handling multicast")

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
                command = input()

                if command.lower() == 'exit':
                    self.tcp_connection.sendall("exit".encode('utf-8'))
                    self.tcp_connection.close()
                    self.m_socket.close()
                    print("Finished sending messages.")
                    break
                message = ""

                while True:
                    ins = input()
                    if ins != "":
                        message += f"{ins}\n"
                    else:
                        break

                if len(message) > 2000:
                    print("Too long message.")
                    continue

                message = f"{self.nickname}:\n{message}"

                if command.startswith('T') or command.startswith('t'):
                    self.tcp_connection.sendall(message.encode('utf-8'))

                if command.startswith('U') or command.startswith('u'):
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

                if command.startswith('M') or command.startswith('m'):
                    multicast_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM, socket.IPPROTO_UDP)
                    multicast_socket.setsockopt(socket.IPPROTO_IP, socket.IP_MULTICAST_TTL, 2)
                    multicast_socket.sendto(message.encode('utf-8'), (self.m_host, self.m_port))
                    multicast_socket.close()

            except Exception as e:
                print(f"Error sending message: {e}")
                break

    def receive_m_messages(self):
        if self.m_socket == None:
            print("Failed to start multicast")
            return
        while True:
            try:
                message = self.m_socket.recv(2048).decode('utf-8')

                if not message.startswith(self.nickname):
                    print(message)

            except OSError as e:
                print("Finished receiving messages.")
                break
            except Exception as e:
                print(f"Error receiving message: {e}")
                break

    def start(self):
        self._receive_thread = threading.Thread(target=self.receive_messages)
        self._receive_m_thread = threading.Thread(target=self.receive_m_messages)
        self._send_thread = threading.Thread(target=self.send_message)

        self._receive_thread.start()
        self._send_thread.start()
        self._receive_m_thread.start()


if __name__ == "__main__":
    HOST = 'localhost'
    PORT = 5555
    nick = input("Enter your nickname: ")

    M_HOST = '224.0.0.2'
    M_PORT = 10000

    if len(nick) > 40:
        print("Failed to start program: too long nick.")
        exit(1)

    client = ChatClient(HOST, PORT, M_HOST, M_PORT, nick)
    client.start()
