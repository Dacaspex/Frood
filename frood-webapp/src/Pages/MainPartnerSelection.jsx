import Card from "../Components/Card/Card";

const storageKeys = {
    homePartnerIdKey: 'home-partner-id-key'
};

const MainPartnerSelection = ({ partners }) => {
    const onSetPartnerAsHome = partnerId => {
        window.localStorage.setItem(storageKeys.homePartnerIdKey, partnerId);
    }

    var partnersJsx = partners.map(partner => {
        return (
            <div className='button button-full-width button-primary'
                 onClick={() => onSetPartnerAsHome(partner.id)}
                 key={ partner.id }>
                { partner.name }
            </div>
        );
    });

    return (
        <>
            <Card header='Select main partner'>
                { partnersJsx }
            </Card>
        </>
    )
}

export default MainPartnerSelection;