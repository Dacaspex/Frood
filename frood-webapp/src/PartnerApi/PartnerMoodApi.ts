import { MoodReport } from "../types";

const PartnerMoodApi = {
    URL: 'undefined',
    HEADER_SPACE_ID: 'X-SpaceId',
    HEADER_PARTNER_SECRET: 'X-PartnerSecret',

    setup: function() {
        this.URL = import.meta.env.VITE_API_URL;
    },

    login: async function(spaceId:string, partnerSecret:string) {
        console.log(this.URL);
        const result = await this._post(this.URL + '/Authentication', spaceId, partnerSecret, { spaceId, partnerSecret });
        return result.ok;
    },

    getSpace: async function(spaceId:string, partnerSecret:string) {
        var response = await this._get(this.URL + '/Api/space/' + spaceId, spaceId, partnerSecret);
        return await response.json();
    },

    updateMoodReport: async function(spaceId:string, partnerSecret:string, partnerId:string, moodReport:MoodReport) {
        return await this._patch(
            this.URL + '/Api/space/' + spaceId + '/moodReport', 
            spaceId, 
            partnerSecret, 
            { partnerId, moodReport }
        );
    },

    _get: async function(url:string, spaceId:string, partnerSecret:string) {
        return await fetch(url, {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                [this.HEADER_SPACE_ID]: spaceId,
                [this.HEADER_PARTNER_SECRET]: partnerSecret
            },
        });
    },

    _post: async function(url:string, spaceId:string, partnerSecret:string, body:Record<string,unknown>) {
        return await fetch(url, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                [this.HEADER_SPACE_ID]: spaceId,
                [this.HEADER_PARTNER_SECRET]: partnerSecret
            },
            body: JSON.stringify(body)
        });
    },

    _patch: async function(url:string, spaceId:string, partnerSecret:string, body:Record<string,unknown>) {
        return await fetch(url, {
            method: 'PATCH',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                [this.HEADER_SPACE_ID]: spaceId,
                [this.HEADER_PARTNER_SECRET]: partnerSecret
            },
            body: JSON.stringify(body)
        });
    }
};

export default PartnerMoodApi;