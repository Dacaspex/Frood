export type Space = {
    name: string;
    id: string;
    partners: Partner[]
}

export type Partner = {
    name: string;
    id: string;
    moodReport: MoodReport;
};

export type MoodReport = {
    globalMood: number;
    updatedAt: string;
    moodCategories: MoodCategory[]
};

export type MoodCategory = {
    id: string;
    name: string;
    moodTopics: MoodTopic[];
}

export type MoodTopic = {
    id: string;
    name: string;
    value: Mood
}

export type Mood = 'YES' | 'INDIFFERENT' | 'NO'
