struct VertexInput {
    @location(0) position: vec3<f32>,
    @location(1) color: vec3<f32>,
};

struct VertexOutput {
    @builtin(position) clip_position: vec4<f32>,
    @location(0) color: vec3<f32>,
};

@group(0) @binding(0) var input_texture: texture_2d<f32>;

@vertex
fn vs_main(
    model: VertexInput,
) -> VertexOutput {
    var out: VertexOutput;
    out.color = model.color;
    out.clip_position = vec4<f32>(model.position, 1.0);

    return out;
}

@fragment
fn fs_main(in: VertexOutput) -> @location(0) vec4<f32> {
    let width = textureDimensions(input_texture).x;
    let height = textureDimensions(input_texture).y;
    let x = ((in.clip_position.x + 1.0) / 2.0) * f32(width);
    let y = ((in.clip_position.y + 1.0) / 2.0) * f32(height);
    return vec4<f32>(x, y, 0.0, 1.0);
}
