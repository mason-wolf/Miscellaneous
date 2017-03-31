#include <SDL.h>
#include <stdio.h>


const int SCREEN_WIDTH = 640;
const int SCREEN_HEIGHT = 480;

int main( int argc, char* args[] )
{

	SDL_Window* window = NULL;

	SDL_Surface* screenSurface = NULL;

	window = SDL_CreateWindow( "", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, SCREEN_WIDTH, SCREEN_HEIGHT, SDL_WINDOW_SHOWN );

	screenSurface = SDL_GetWindowSurface( window );

	SDL_UpdateWindowSurface( window );

	SDL_Delay( 2000 );

	SDL_DestroyWindow( window );

	SDL_Quit();

	return 0;
}
