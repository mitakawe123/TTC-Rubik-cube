const BASE_URL = "http://localhost:5272/api/cube";

export async function getCubeState() {
	const res = await fetch(`${BASE_URL}/state`);
	return res.json();
}

export async function rotateCube(face: number, clockwise: boolean) {
	const res = await fetch(`${BASE_URL}/rotate`, {
		method: "PATCH",
		headers: { "Content-Type": "application/json" },
		body: JSON.stringify({ face, clockwise }),
	});
	return res.ok;
}

export async function resetCube() {
	const res = await fetch(`${BASE_URL}/reset`, { method: "PATCH" });
	return res.ok;
}

export async function scrambleCube() {
	const res = await fetch(`${BASE_URL}/scramble`, { method: "PATCH" });
	return res.ok;
}
