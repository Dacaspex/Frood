import { useContext, useEffect, useState } from 'react';
import MainPartnerSelection from './MainPartnerSelection'
import PartnerCardList from './PartnerCardList';
import MoodReport from './MoodReport';
import PartnerMoodApi from '../PartnerApi/PartnerMoodApi';
import { AuthenticationContext } from '../Contexts/AuthenticationContext';
import { MoodReport as MoodReportType, Space } from '../types';

const storageKeys = {
    homePartnerIdKey: 'home-partner-id-key'
};

const SpaceContainer = () => {
    const authenticationContext = useContext(AuthenticationContext);

    let [fetching, setFetching] = useState<boolean>(true);
    let [space, setSpace] = useState<Space|null>(null);

    const onSave = async (partnerId:string, moodReport:MoodReportType) => {
        setFetching(true);
        await PartnerMoodApi.updateMoodReport(
            authenticationContext.spaceId,
            authenticationContext.partnerSecret,
            partnerId,
            moodReport
        );
        setFetching(false);
    }

    useEffect(() => {
        async function fetchData() {
            var spaceResponse = await PartnerMoodApi.getSpace(authenticationContext.spaceId, authenticationContext.partnerSecret);
            setSpace(spaceResponse);
            setFetching(false);
        }

        setFetching(true);
        fetchData();
        // setSpace({
        //     name: 'My space',
        //     id: 1,
        //     partners: [
        //         {
        //             name: 'Casper',
        //             id: 1,
        //             moodReport: {
        //                 globalMood: 6,
        //                 updatedAt: '29-10-1997',
        //                 moodCategories: [
        //                     {
        //                         id: 1,
        //                         name: 'Sports',
        //                         moodTopics: [
        //                             {
        //                                 id: 1,
        //                                 name: 'Running',
        //                                 value: 'YES'
        //                             },
        //                             {
        //                                 id: 2,
        //                                 name: 'Swimming',
        //                                 value: 'INDIFFERENT'
        //                             },
        //                             {
        //                                 id: 3,
        //                                 name: 'Climbing',
        //                                 value: 'YES'
        //                             }
        //                         ]
        //                     }
        //                 ]
        //             }
        //         },
        //         {
        //             name: 'Tom',
        //             id: 2,
        //             moodReport: {
        //                 globalMood: 6,
        //                 updatedAt: '29-10-1997',
        //                 moodCategories: [
        //                     {
        //                         name: 'Sports',
        //                         moodTopics: [
        //                             {
        //                                 name: 'Running',
        //                                 value: 'YES'
        //                             }
        //                         ]
        //                     }
        //                 ]
        //             }
        //         }
        //     ]
        // })
        
    }, []);

    if (fetching || space === null) {
        return (
            <span>Fetching data...</span>
        )
    }

    const homePartnerId = window.localStorage.getItem(storageKeys.homePartnerIdKey);
    if (homePartnerId === null) {
        return <MainPartnerSelection partners={ space.partners }/>;
    }

    const myself = space.partners[0];
    const partners = [space.partners[1]];

    return (
        <>
            <PartnerCardList 
                partners={ partners } />
            <MoodReport 
                moodReport={ myself.moodReport }
                onSave={ () => onSave(myself.id, myself.moodReport) } />
        </>
    )
}

export default SpaceContainer;