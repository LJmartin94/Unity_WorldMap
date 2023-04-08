#include <stdio.h>
#include "MLX42.h"

// #include <stdlib.h>
// #include <stdio.h>
// #include <unistd.h>
// #include <memory.h>

// mlx_image_t	*g_img;

// void	movement(mlx_key_data_t keydata, void* param)
// {
// 	t_data		*d;
// 	t_coords	new_pos;
// 	bool		hold_or_repeat;

// 	d = param;
// 	hold_or_repeat = keydata.action == MLX_REPEAT || keydata.action == MLX_PRESS;
// 	new_pos = d->player;
// 	if (keydata.key == MLX_KEY_ESCAPE && hold_or_repeat)
// 		mlx_close_window(d->mlx);
// 	if (keydata.key == MLX_KEY_UP &&  hold_or_repeat)
// 		new_pos.y -= 1;
// 	if (keydata.key == MLX_KEY_DOWN &&  hold_or_repeat)
// 		new_pos.y += 1;
// 	if (keydata.key == MLX_KEY_LEFT &&  hold_or_repeat)
// 		new_pos.x -= 1;
// 	if (keydata.key == MLX_KEY_RIGHT &&  hold_or_repeat)
// 		new_pos.x += 1;
// 	if (d->map[new_pos.y][new_pos.x] != '1')
// 	{
// 		d->player = new_pos;
// 		g_img->instances[0].y = new_pos.y * d->unit.y;
// 		g_img->instances[0].x = new_pos.x * d->unit.x;
// 	}
// }

// // void	hook(void *param) //continuous movement
// // {
// // 	t_data		*d;
// // 	t_coords	dist;

// // 	d = param;
// // 	dist = d->unit;
// // 	if (mlx_is_key_down(d->mlx, MLX_KEY_ESCAPE))
// // 		mlx_close_window(d->mlx);
// // 	if (mlx_is_key_down(d->mlx, MLX_KEY_UP))
// // 		g_img->instances[0].y -= dist.y;
// // 	if (mlx_is_key_down(d->mlx, MLX_KEY_DOWN))
// // 		g_img->instances[0].y += dist.y;
// // 	if (mlx_is_key_down(d->mlx, MLX_KEY_LEFT))
// // 		g_img->instances[0].x -= dist.x;
// // 	if (mlx_is_key_down(d->mlx, MLX_KEY_RIGHT))
// // 		g_img->instances[0].x += dist.x;
// // }

// int	yoink(t_data *d)
// {
// 	int			width;
// 	int			height;

// 	// mlx_set_setting(MLX_STRETCH_IMAGE, true);
// 	// mlx_set_setting(MLX_FULLSCREEN, true); //Cinematic, baby!
// 	d->mlx = mlx_init(2560, 1440, "MLX42", true);
// 	if (!d->mlx)
// 		exit(EXIT_FAILURE);
// 	mlx_get_monitor_size(0, &width, &height);
// 	d->unit = (t_coords){width / d->map_width, height / d->map_len};
// 	// printf("width: %d, height: %d, d->unit.x: %d, d->unit.y: %d\n", width, height, d->unit.x, d->unit.y);
// 	width = d->map_width * d->unit.x;
// 	height = d->map_len * d->unit.y;
// 	// printf("width: %d, height: %d, d->unit.x: %d, d->unit.y: %d\n", width, height, d->unit.x, d->unit.y);
// 	mlx_set_window_size(d->mlx, width, height);

	


	
// 	g_img = mlx_new_image(d->mlx, d->unit.x, d->unit.y);
// 	mlx_image_t *wall;
// 	wall = mlx_new_image(d->mlx, d->unit.x, d->unit.y);
// 	memset(wall->pixels, 255, wall->width * wall->height * sizeof(int));

// 	int i = 0;
// 	while (i < d->map_width * d->map_len)
// 	{
// 		t_coords here = (t_coords){i % d->map_width, i / d->map_width};
// 		if (d->map[here.y][here.x] == '1')
// 			mlx_image_to_window(d->mlx, wall, here.x * d->unit.x, \
// 			here.y * d->unit.y);
// 		i++;
// 	}
	
// 	memset(g_img->pixels, 255, g_img->width * g_img->height * sizeof(int));
// 	mlx_image_to_window(d->mlx, g_img, d->player.x * d->unit.x, d->player.y * d->unit.y);
// 	// mlx_loop_hook(d->mlx, &hook, d); //continuous movement
// 	mlx_key_hook(d->mlx, &movement, d); //step-wise movement
// 	mlx_loop(d->mlx);
// 	mlx_terminate(d->mlx);
// 	return (EXIT_SUCCESS);
// }



int main(void)
{
	//Initialise MLX
	int width = 360;
	int height = 360;
	bool full_screen = false;
	mlx_t *mlx = mlx_init(width, height, "MLX42", true);
	if (!mlx)
		return(1);
	
	//Fullscreen the app
	if (full_screen)
	{
		mlx_get_monitor_size(0, &width, &height);
		mlx_set_window_size(mlx, width, height);
	}

	printf("Hello world, literally.\n");
	mlx_loop(mlx);
	return (0);
}