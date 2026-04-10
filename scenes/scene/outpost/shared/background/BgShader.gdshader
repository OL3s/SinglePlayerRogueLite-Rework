shader_type canvas_item;

uniform float move_speed = 0.18;
uniform float wave_strength = 0.01;   // keep low for pixel art
uniform float wave_scale = 11.0;
uniform float shimmer_strength = 0.015;
uniform float pulse_strength = 0.1;

// 0 = off, 1 = on
uniform float enable_hot_side_motion = 1.0;

void fragment() {
    vec2 uv = UV;

    float t = TIME * move_speed;

    // Large soft movement
    float wave1 = sin((uv.y * wave_scale) + t) * wave_strength;
    float wave2 = cos((uv.y * (wave_scale * 0.6)) - t * 0.7) * wave_strength * 0.6;

    // More motion toward horizon, less near foreground
    float horizon_mask = smoothstep(0.15, 0.75, 1.0 - uv.y);

    // Extra subtle motion on hot/right side
    float hot_mask = smoothstep(0.55, 1.0, uv.x) * enable_hot_side_motion;
    float hot_wave = sin((uv.y * 28.0) + t * 1.8 + uv.x * 10.0) * wave_strength * 0.8;

    uv.x += (wave1 + wave2) * horizon_mask;
    uv.x += hot_wave * hot_mask * horizon_mask;

    vec4 col = texture(TEXTURE, uv);

    // Very light atmospheric shimmer
    float shimmer = sin(t * 1.3 + uv.x * 8.0 + uv.y * 6.0) * shimmer_strength;
    col.rgb += shimmer * 0.15 * horizon_mask;

    // Gentle global pulse
    float pulse = 1.0 + sin(TIME * 0.7) * pulse_strength;
    col.rgb *= mix(1.0, pulse, 0.35);

    COLOR = col;
}