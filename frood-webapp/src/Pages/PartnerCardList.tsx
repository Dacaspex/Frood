import { Partner } from "../types";

type Props = {
    partners:Partner[]
}

const PartnerCardList = ({ partners }:Props) => {
    return partners.map(partner => {
        return (
            <div className='card card-primary card-partner' key={ partner.id }>
                <div className='card-partner-left'>
                    <div className='card-partner-header'>{ partner.name }</div>
                    <div className='card-partner-sub'>Last updated <span className='card-partner-updated'>{ partner.moodReport.updatedAt }</span></div>
                </div>
                <div className='card-partner-right'>
                    <span>{ partner.moodReport.globalMood }</span>
                </div>
            </div>
        );
    });
}

export default PartnerCardList;