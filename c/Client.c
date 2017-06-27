#include<stdio.h>
#include<winsock2.h>
 
int main()
{
    WSADATA wsa;
    SOCKET s;
    struct sockaddr_in server;
    char *message , server_reply[5000];
    int recv_size;
    WSAStartup(MAKEWORD(2, 2), &wsa);
    s = socket(AF_INET, SOCK_STREAM, 0);
    server.sin_addr.s_addr = inet_addr("131.55.137.92");
    server.sin_family = AF_INET;
    server.sin_port = htons(8080);

    printf("\nConnecting to %s..", inet_ntoa(server.sin_addr));
    printf("\n");

    if(connect(s , (struct sockaddr *)&server , sizeof(server)) == SOCKET_ERROR) {
        printf("\n\nConnection failed.\n");
        exit(0);
    }

    while (1) {
        printf(">");
        message = malloc(256);
        scanf("%s", message);
        if(send(s, message, strlen(message), 0) == SOCKET_ERROR) {
            printf("\nDisconnected..\n");
            exit(0);
        }
        recv_size = recv(s, server_reply, 5000, 0);

        int i;
        for (i = 0; i < recv_size; i++) {
              putc(server_reply[i], stdout);
        }

    }
    
    closesocket(s);
    WSACleanup();
}
