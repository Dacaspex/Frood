import Card from "../Components/Card/Card";
import { Partner } from "../types";

type Props = {
    partners: Partner[];
};

const storageKeys = {
    homePartnerIdKey: "home-partner-id-key",
};

const MainPartnerSelection = ({ partners }: Props) => {
    const onSetPartnerAsHome = (partnerId: string) => {
        window.localStorage.setItem(storageKeys.homePartnerIdKey, partnerId);
    };

    var partnersJsx = partners.map((partner) => {
        return (
            <div
                className="button button-full-width button-primary"
                onClick={() => onSetPartnerAsHome(partner.id)}
                key={partner.id}
            >
                {partner.name}
            </div>
        );
    });

    return <Card header="Select main partner">{partnersJsx}</Card>;
};

export default MainPartnerSelection;
