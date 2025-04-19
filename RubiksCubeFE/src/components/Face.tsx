import Tile from "./Tile";

export default function Face({ face }: { face: string[][] }) {
	return (
		<div className="grid grid-cols-3 gap-0.5">
			{face.flat().map((color, idx) => (
				<Tile key={idx} color={color} />
			))}
		</div>
	);
}
