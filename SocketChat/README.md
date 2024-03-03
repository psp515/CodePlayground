# SocketChat

Task is to create simple console chat application sending messages using sockets. Task is divided into 3 parts:
- part 1 - tcp client and server
- part 2 - sending asci art over udp
- part 3 - sending asci art over udp using mutlicast (serverless)

### Client

Operations:
- ``` T ``` - send message over tcp (using utf-8 encoding)
- ``` U ``` - send message over udp
- ``` M ``` - send emssage over multicast
- ``` exit ``` - close client program

First you type command then you provide paylaod. Empty string means end of payload. (Tap enter on enpty string to acknowledge)

### Server

Server is just accepting connections and diplaying communicates.

### Comments 

#### Part 1

Connection over tcp guarantess sending and receiving messages. Worth noting is that when we close connection we also should be aware that receiving thread will encouter exception because socket is no longer available. Similar exception is encountered in server.

#### Part 2 

Combining both tcp and Udp gives nice working together where we are sending data to server by udp and server is responsible for transmitting data to clients.

Example message:
        _____________  
   _|___|______|______|
  /___________________|
 |    ___ ___ ___     |
 |   |___|___|___|    |
 |                     |
 |   _ _ _ _ _ _ _ _  |
 |  |_|_|_|_|_|_|_|_| |
 |_____________________|

    ____        _   _   _       ____  _           _   _     
  |  _ \ _   _| |_| |_| | ___ / ___|| |__   __ _| |_| |__  
  | |_) | | | | __| __| |/ _ \ |  _| '_ \ / _` | __| '_ \ 
  |  __/| |_| | |_| |_| |  __/ |_| | | | | (_| | |_| | | |
  |_|    \__,_|\__|\__|_|\___|\____|_| |_|\__,_|\__|_| |_| 


#### Part 3

Multicasting allows multiple processes to listen on single port such abiliti could be really usefull when we need prcesses just to read some data and such single endpoint could be great.


#### Sumamry

Also worth noting is that after process is killed, operating system closes unused sockets in order to save ports. 