shader_type canvas_item;

uniform vec4 color_a : source_color = vec4(0.25, 0.45, 0.90, 1.0);
uniform vec4 color_b : source_color = vec4(0.55, 0.85, 1.0, 1.0);

uniform float swirl_strength = 0.18;
uniform float fragment_density = 6.0;
uniform float edge_softness = 0.12;
uniform float alpha_strength = 0.85;
uniform float speed = 0.6;

float hash(vec2 p) {
    return fract(sin(dot(p, vec2(127.1, 311.7))) * 43758.5453123);
}

float noise(vec2 p) {
    vec2 i = floor(p);
    vec2 f = fract(p);

    float a = hash(i);
    float b = hash(i + vec2(1.0, 0.0));
    float c = hash(i + vec2(0.0, 1.0));
    float d = hash(i + vec2(1.0, 1.0));

    vec2 u = f * f * (3.0 - 2.0 * f);

    return mix(a, b, u.x) +
           (c - a) * u.y * (1.0 - u.x) +
           (d - b) * u.x * u.y;
}

vec2 swirl_uv(vec2 uv, float time) {
    vec2 p = uv - 0.5;
    float r = length(p);
    float a = atan(p.y, p.x);

    a += (1.0 - r) * swirl_strength * sin(time * 0.8 + r * 10.0);

    vec2 out_uv = vec2(cos(a), sin(a)) * r;
    out_uv += 0.5;

    out_uv.x += sin(uv.y * 8.0 + time) * 0.03;
    out_uv.y += cos(uv.x * 7.0 - time * 0.7) * 0.03;

    return out_uv;
}

void fragment() {
    vec2 uv = swirl_uv(UV, TIME * speed);

    float n1 = noise(uv * fragment_density + TIME * 0.15);
    float n2 = noise(uv * (fragment_density * 1.8) - TIME * 0.10);
    float n = n1 * 0.7 + n2 * 0.3;

    float mask = smoothstep(0.52, 0.52 + edge_softness, n);

    float streak = sin((uv.x + uv.y) * 10.0 + TIME * 0.8) * 0.5 + 0.5;
    float color_mix = clamp(n * 0.8 + streak * 0.2, 0.0, 1.0);

    vec3 col = mix(color_a.rgb, color_b.rgb, color_mix);

    COLOR = vec4(col, mask * alpha_strength);
}