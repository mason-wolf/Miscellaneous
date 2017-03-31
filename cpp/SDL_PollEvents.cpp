#include <SDL.h>
#include <stdio.h>


const int SCREEN_WIDTH = 640;
const int SCREEN_HEIGHT = 480;


bool init();
void close();

SDL_Window* gWindow = NULL;
SDL_Surface* gScreenSurface = NULL;
SDL_Surface* gXOut = NULL;

bool init()
{
		gWindow = SDL_CreateWindow( "", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, SCREEN_WIDTH, SCREEN_HEIGHT, SDL_WINDOW_SHOWN );
}

void close()
{
	SDL_FreeSurface( gXOut );
	gXOut = NULL;
	SDL_DestroyWindow( gWindow );
	gWindow = NULL;
	SDL_Quit();
}

int main( int argc, char* args[] )
{
			init();

			bool quit = false;

			// poll event, when user clicks exit button
			
			SDL_Event e;

			while( !quit )
			{
				while( SDL_PollEvent( &e ) != 0 )
				{
					if( e.type == SDL_QUIT )
					{
						quit = true;
					}
				}

				SDL_BlitSurface( gXOut, NULL, gScreenSurface, NULL );
				SDL_UpdateWindowSurface( gWindow );

			}

	close();
	return 0;

}
