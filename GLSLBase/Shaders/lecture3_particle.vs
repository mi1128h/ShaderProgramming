#version 450

in vec3 a_Position;
in vec3 a_Velocity;
in float a_EmitTime;
in float a_LifeTime;
in float a_Amp;
in float a_Period;
in float a_Value;
in vec4 a_Color;

out vec4 v_Color;

uniform float u_Time;
uniform vec3 u_Accel;

bool bLoop = true;	// ¼÷Á¦

const float g_PI = 3.14;
const mat3 g_RotMat = mat3(0, -1, 0, 1, 0, 0, 0, 0, 0);
const vec3 g_Gravity = vec3(0, -0.5, 0);

void main()
{
	vec3 newPos;
	float t = u_Time - a_EmitTime;
	float tt = t * t;
	if(t > 0)
	{
		vec3 newAccel = g_Gravity + a_Velocity;
		newPos.x = sin(a_Value * 2 * g_PI);
		newPos.y = cos(a_Value * 2 * g_PI);
		newPos.z = 0;
		newPos = a_Position + newPos;

		float temp = t / a_LifeTime;
		float fractional = fract(temp);
		t = fractional * a_LifeTime;
		tt = t * t;

		float amp = a_Amp;
		float period = a_Period;
		newPos = newPos + newAccel * t + 0.5 * u_Accel * tt;

		vec3 rotVec = normalize(newAccel * g_RotMat);

		newPos = newPos + 0.1 * amp * rotVec * sin(period * t * 2.0 * g_PI);
		newPos.z = 0;
	}
	else
	{
		newPos = vec3(-100000, -100000, -100000);
	}
	gl_Position = vec4(newPos, 1);
	v_Color = a_Color;
}
