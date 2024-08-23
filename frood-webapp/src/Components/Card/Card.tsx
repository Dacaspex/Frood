import { ReactNode } from "react";

type Props = {
    children: ReactNode;
    header: string;
};

const Card = ({ children, header }: Props) => {
    return (
        <div className="card-container mt-x">
            <div className="card-header">{header}</div>
            <div className="card">{children}</div>
        </div>
    );
};

export default Card;
