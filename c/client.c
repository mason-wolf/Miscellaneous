#include<stdio.h>
#include<winsock2.h>
 
 // socket programming, client
 // build with gcc client.c -o client.exe -lws2_32
 
int main()
{
    WSADATA wsa;
    SOCKET s;
    struct sockaddr_in server;
    char *message , server_reply[2000];
    int recv_size;
    WSAStartup(MAKEWORD(2, 2), &wsa);
    s = socket(AF_INET, SOCK_STREAM, 0);
    server.sin_addr.s_addr = inet_addr("131.55.137.92");
    server.sin_family = AF_INET;
    server.sin_port = htons(8080);
    connect(s , (struct sockaddr *)&server , sizeof(server));

    while (1) {
        printf(">");
        message = malloc(256);
        scanf("%s", message);
        send(s, message, strlen(message), 0);
        recv_size = recv(s, server_reply, 2000, 0);
        server_reply[recv_size] = '\0';
        printf("%s\n", server_reply);
    }
    
    closesocket(s);
    WSACleanup();
}
