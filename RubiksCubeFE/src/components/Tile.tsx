type TileProps = {
	color: string;
};

export default function Tile({ color }: TileProps) {
	return (
		<div
			className="w-8 h-8 border border-gray-300 flex items-center justify-center text-sm font-bold"
			style={{ backgroundColor: mapColor(color), color: "#000" }}
		>
			{color}
		</div>
	);
}

function mapColor(letter: string): string {
	switch (letter) {
		case "R":
			return "red";
		case "G":
			return "green";
		case "B":
			return "blue";
		case "O":
			return "orange";
		case "W":
			return "white";
		case "Y":
			return "yellow";
		default:
			return "#ccc";
	}
}
