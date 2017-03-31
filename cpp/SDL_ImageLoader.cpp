#include <SDL.h>
#include <stdio.h>


const int SCREEN_WIDTH = 640;
const int SCREEN_HEIGHT = 480;

void init();
void loadMedia();
void close();
SDL_Window*  gWindow = NULL;
SDL_Surface* gScreenSurface = NULL;
SDL_Surface* gImageLoader = NULL;

void init()
{
		gWindow = SDL_CreateWindow("", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, SCREEN_WIDTH, SCREEN_HEIGHT, SDL_WINDOW_SHOWN);
		gScreenSurface = SDL_GetWindowSurface(gWindow);
}

void loadMedia()
{
	gImageLoader= SDL_LoadBMP(".bmp");
}

void close()
{
	SDL_FreeSurface(gImageLoader);
	gImageLoader = NULL;
	SDL_DestroyWindow(gWindow);
	gWindow = NULL;
	SDL_Quit();
}

int main(int argc, char* args[])
{
			init();
			loadMedia();
			SDL_BlitSurface(gImageLoader, NULL, gScreenSurface, NULL);
			SDL_UpdateWindowSurface(gWindow);
			SDL_Delay(1000);
			close();
			return 0;
}
