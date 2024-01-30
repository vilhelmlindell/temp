shader_type canvas_item;

uniform float pixelate: hint_range(2, 512, 2) = 256;
uniform sampler2D screen_texture : hint_screen_texture, filter_linear_mipmap;

void fragment() {
	vec2 uv = floor(UV * pixelate) / pixelate;
	COLOR = textureLod(screen_texture, uv, 0.0);
}
