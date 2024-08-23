import { useState } from "react";

type Props = { initialState: string; onStateUpdated: (value: string) => void };

const TrafficLight = ({ initialState, onStateUpdated }: Props) => {
    const [state, setState] = useState<string>(initialState);

    const redActive = state == "red";
    const orangeActive = state == "orange";
    const greenActive = state == "green";

    const updateState = (newState: string) => {
        setState(newState);
        if (onStateUpdated !== undefined) onStateUpdated(newState);
    };

    return (
        <div className="trafficlight-container">
            <div
                className={`trafficlight-pill trafficlight-red ${redActive ? "active" : ""}`}
                onClick={() => updateState("red")}
            />
            <div
                className={`trafficlight-pill trafficlight-orange ${orangeActive ? "active" : ""}`}
                onClick={() => updateState("orange")}
            />
            <div
                className={`trafficlight-pill trafficlight-green ${greenActive ? "active" : ""}`}
                onClick={() => updateState("green")}
            />
        </div>
    );
};

export default TrafficLight;
