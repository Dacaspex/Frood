
const PartnerMoodApi = {
    URL: 'http://localhost:5166',
    HEADER_SPACE_ID: 'X-SpaceId',
    HEADER_PARTNER_SECRET: 'X-PartnerSecret',

    login: async function(spaceId, partnerSecret) {
        const result = await this._post(this.URL + '/Authentication', { spaceId, partnerSecret });
        return result.ok;
    },

    getSpace: async function(spaceId, partnerSecret) {
        var response = await this._get(this.URL + '/Api/space/' + spaceId, spaceId, partnerSecret);
        return await response.json();
    },

    updateMoodReport: async function(spaceId, partnerSecret, partnerId, moodReport) {
        return await this._patch(
            this.URL + '/Api/space/' + spaceId + '/moodReport', 
            spaceId, 
            partnerSecret, 
            { partnerId, moodReport }
        );
    },

    _get: async function(url, spaceId, partnerSecret) {
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

    _patch: async function(url, spaceId, partnerSecret, body) {
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