# SocketChat

Task is to create simple console chat application sending messages using sockets. Task is divided into 3 parts:
- part 1 - tcp client and server
- part 2 - sending asci art over udp
- part 3 - sending asci art over udp using mutlicast (serverless)

### Client

Operations:
- ``` T <text>``` - send message over tcp (using utf-8 encoding)
- ``` U <text>``` - send message over udp
- ``` M <text>``` - send emssage over multicast
- ``` exit ``` - close client program

### Server

Server is just accepting connections and diplaying communicates.

### Comments 

#### Part 1

Connection over tcp guarantess sending and receiving messages. Worth noting is that when we close connection we also should be aware that receiving thread will encouter exception because socket is no longer available. Similar exception is encountered in server.

#### Part 2 

Combining both tcp and Udp gives nice working together where we are sending data to server by udp and server is responsible for transmitting data to clients.

Example message:

U       _____________
U   _|___|______|______|
U  /___________________|
U |    ___ ___ ___     |
U |   |___|___|___|    |
U |                     |
U |   _ _ _ _ _ _ _ _  |
U |  |_|_|_|_|_|_|_|_| |
U |_____________________|

#### Part 3
