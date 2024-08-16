import Card from '../Components/Card/Card';
import TrafficLight from '../Components/TrafficLight/TrafficLight';

const trafficLightToMood = colour => {
    switch (colour) {
        case 'red':
            return 'NO';
        case 'orange':
            return 'INDIFFERENT';
        case 'green':
            return 'YES';
    };
}

const moodToTrafficLight = mood => {
    switch (mood.toUpperCase()) {
        case 'NO':
            return 'red';
        case 'INDIFFERENT':
            return 'orange';
        case 'YES':
            return 'green';
    };
}

const MoodReport = ({ moodReport, onSave }) => {
    const onStateUpdated = (category, topic, colour) => {
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