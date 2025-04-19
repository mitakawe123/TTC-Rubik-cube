import { useEffect, useState } from "react";
import {
	getCubeState,
	rotateCube,
	resetCube,
	scrambleCube,
} from "../api/cubeApi";
import Cube from "../components/Cube";

export default function Home() {
	const ClockwiseFaces = ["Front", "Back", "Up", "Down", "Left", "Right"];
	const CounterClockwiseFaces = [
		"Front'",
		"Back'",
		"Up'",
		"Down'",
		"Left'",
		"Right'",
	];

	const [faces, setFaces] = useState<string[][][]>([]);

	const fetchState = async () => {
		const data = await getCubeState();
		// Convert string face to 2D array
		const parsed = data.faces.map((face: string) =>
			face
				.trim()
				.split("\n")
				.map((row) => row.trim().split(" "))
		);
		setFaces(parsed);
	};

	const handleRotate = async (face: number, clockwise = true) => {
		await rotateCube(face, clockwise);
		fetchState();
	};

	const handleReset = async () => {
		await resetCube();
		fetchState();
	};

	const handleScramble = async () => {
		await scrambleCube();
		fetchState();
	};

	useEffect(() => {
		fetchState();
	}, []);

	return (
		<div className="p-4 flex flex-col items-center gap-4">
			<Cube faces={faces} />
			<div className="flex gap-2 flex-wrap justify-center">
				{ClockwiseFaces.map((name, idx) => (
					<button
						key={name}
						onClick={() => handleRotate(idx, true)}
						className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
					>
						{name}
					</button>
				))}
			</div>
			<div className="flex gap-2 flex-wrap justify-center">
				{CounterClockwiseFaces.map((name, idx) => (
					<button
						key={name}
						onClick={() => handleRotate(idx, false)}
						className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
					>
						{name}
					</button>
				))}
			</div>
			<div className="flex gap-2 flex-wrap justify-center">
				<button
					onClick={handleReset}
					className="bg-red-500 text-white px-4 py-2 rounded hover:bg-red-600"
				>
					Reset
				</button>
				<button
					onClick={handleScramble}
					className="bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600"
				>
					Scramble
				</button>
			</div>
		</div>
	);
}
