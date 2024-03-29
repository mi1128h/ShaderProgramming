#version 450

layout(location=0) out vec4 FragColor;

in vec2 v_TexCoord;

uniform sampler2D u_TexSampler;
uniform sampler2D u_TexSampler1;

uniform float u_Time;

vec4 Flip()
{
	vec4 returnValue = vec4(0);
	vec2 newTexCoord = v_TexCoord;
	newTexCoord = vec2(v_TexCoord.x, 1.0 - v_TexCoord.y);
	returnValue = texture(u_TexSampler, newTexCoord);
	return returnValue;
}

vec4 P1()
{
	vec4 returnValue = vec4(0);
	vec2 newTexCoord = v_TexCoord;

	newTexCoord.y = abs(2.0 * (v_TexCoord.y - 0.5));
	//if (v_TexCoord.y > 0.5)
	//{
	//	newTexCoord = vec2(v_TexCoord.x, v_TexCoord.y * 2);
	//}
	//else
	//{
	//	newTexCoord = vec2(v_TexCoord.x, (1 - v_TexCoord.y) * 2);
	//}
	// if문이 Shader에 존재하면 느려진다

	returnValue = texture(u_TexSampler, newTexCoord);
	return returnValue;
}

vec4 P2()
{
	vec4 returnValue = vec4(0);
	vec2 newTexCoord = v_TexCoord;
	newTexCoord.x = fract(v_TexCoord.x * 3);
	newTexCoord.y = v_TexCoord.y / 3.0 + floor(v_TexCoord.x * 3) / 3.0;

	returnValue = texture(u_TexSampler, newTexCoord);
	return returnValue;
}

vec4 P3()
{
	vec4 returnValue = vec4(0);
	vec2 newTexCoord = v_TexCoord;
	newTexCoord.x = fract(v_TexCoord.x * 3);
	newTexCoord.y = v_TexCoord.y / 3.0 - floor(v_TexCoord.x * 3) / 3.0 + 2.0/3.0;

	returnValue = texture(u_TexSampler, newTexCoord);
	return returnValue;
}

vec4 P4()
{
	vec4 returnValue = vec4(0);
	vec2 newTexCoord = v_TexCoord;
	newTexCoord.y = fract(v_TexCoord.y * 3) / 3.0 + 2.0/3.0 - floor(v_TexCoord.y * 3) / 3.0;

	returnValue = texture(u_TexSampler, newTexCoord);
	return returnValue;
}

vec4 P5()
{
	vec4 returnValue = vec4(0);
	vec2 newTexCoord = v_TexCoord;

	float x = 4.0;
	float y = 3.0;
	newTexCoord.x = fract(v_TexCoord.x * x) + floor(v_TexCoord.y * y) * 0.5;
	newTexCoord.y = fract(v_TexCoord.y * y);

	returnValue = texture(u_TexSampler, newTexCoord);
	return returnValue;
}

vec4 P6()
{
	vec4 returnValue = vec4(0);
	vec2 newTexCoord = v_TexCoord;

	newTexCoord.x = fract(v_TexCoord.x * 2);

	if(v_TexCoord.x > 0.5)
	{
		returnValue = texture(u_TexSampler1, newTexCoord);
	}
	else
	{
		returnValue = texture(u_TexSampler, newTexCoord);
	}
	return returnValue;
}

vec4 P7()
{
	vec4 returnValue = vec4(0);
	vec2 newTexCoord = v_TexCoord;
	vec2 newTexCoord1 = v_TexCoord;
	newTexCoord1.x += u_Time;
	newTexCoord1.x = fract(newTexCoord1.x);

	returnValue = texture(u_TexSampler, newTexCoord) * texture(u_TexSampler1, newTexCoord1);
	return returnValue;
}

void main()
{
	//FragColor = Flip();
	FragColor = P7();
	//FragColor = vec4(1,1,1,1);
}
