import { FC } from "react";
import Face from "./Face";

interface CubeProps {
	faces: string[][][]; // Array of 6 faces, each a 3x3 array
}

const Cube: FC<CubeProps> = ({ faces }) => {
    if (faces.length !== 6)
        return null;

	return (
		<div className="flex flex-col items-center gap-2">
			{/* UP */}
			<div className="h-24 flex justify-center">
				<Face face={faces[2]} />
			</div>

			{/* LEFT, FRONT, RIGHT, BACK */}
			<div className="flex gap-2">
				<Face face={faces[4]} />
				<Face face={faces[0]} />
				<Face face={faces[5]} />
				<Face face={faces[1]} />
			</div>

			{/* DOWN */}
			<div className="h-24 flex justify-center">
				<Face face={faces[3]} />
			</div>
		</div>
	);
};

export default Cube;
