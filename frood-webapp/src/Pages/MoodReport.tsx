import Card from '../Components/Card/Card';
import TrafficLight from '../Components/TrafficLight/TrafficLight';
import { MoodCategory, MoodTopic, MoodReport as MoodReportType, Mood } from '../types';

type Props = {
    moodReport: MoodReportType;
    onSave: () => void; 
}

function trafficLightToMood(colour: string): Mood {
    switch (colour) {
        case 'red':
            return 'NO';
        case 'orange':
            return 'INDIFFERENT';
        case 'green':
            return 'YES';
        default:
            throw Error();
    };
}

function moodToTrafficLight(mood: Mood):string {
    switch (mood.toUpperCase()) {
        case 'NO':
            return 'red';
        case 'INDIFFERENT':
            return 'orange';
        case 'YES':
            return 'green';
        default:
            throw Error();
    };
}

const MoodReport = ({ moodReport, onSave }:Props) => {
    const onStateUpdated = (category:MoodCategory, topic:MoodTopic, colour:string) => {
        const mood = trafficLightToMood(colour);

        for (const moodCategory of moodReport.moodCategories) {
            if (moodCategory.id !== category.id) continue;
            
            for (const moodTopic of moodCategory.moodTopics) {
                if (moodTopic.id !== topic.id) continue;
                moodTopic.value = mood;
            }
        }
    }

    const moodCategoriesJsx = moodReport.moodCategories.map(category => {
        const moodTopicsJsx = category.moodTopics.map(topic => {
            const colour = moodToTrafficLight(topic.value);
            return (
                <div className='card-item' key={ topic.name } >
                    <div className='card-item-name'>{ topic.name }</div>
                    <div className='card-item-rating'>
                        <TrafficLight initialState={ colour } onStateUpdated={ colour => onStateUpdated(category, topic, colour ) }/>
                    </div>
                </div>
            );
        });

        return (
            <Card header={ category.name } key={ category.name }>
                <div className='card-list'>{ moodTopicsJsx }</div>
            </Card>
        );
    });

    return (
        <>
            { moodCategoriesJsx }
            <div className='button button-full-width button-primary mt-m' onClick={ () => onSave() }>
                Save
            </div>
        </>
    );
};

export default MoodReport;