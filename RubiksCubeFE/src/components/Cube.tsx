import { FC } from "react";
import Face from "./Face";

interface CubeProps {
	faces: string[][][]; // Array of 6 faces, each a 3x3 array
}

const Cube: FC<CubeProps> = ({ faces }) => {
	if (faces.length !== 6) return null;

	return (
		<div className="grid grid-cols-4 grid-rows-3 gap-2 place-items-center">
			{/* UP face (top center) */}
			<div className="col-start-2 row-start-1">
				<Face face={faces[2]} />
			</div>

			{/* LEFT, FRONT, RIGHT, BACK (middle row) */}
			<div className="col-start-1 row-start-2">
				<Face face={faces[4]} />
			</div>
			<div className="col-start-2 row-start-2">
				<Face face={faces[0]} />
			</div>
			<div className="col-start-3 row-start-2">
				<Face face={faces[5]} />
			</div>
			<div className="col-start-4 row-start-2">
				<Face face={faces[1]} />
			</div>

			{/* DOWN face (bottom center) */}
			<div className="col-start-2 row-start-3">
				<Face face={faces[3]} />
			</div>
		</div>
	);
};

export default Cube;
