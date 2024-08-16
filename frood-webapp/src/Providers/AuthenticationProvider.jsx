import { AuthenticationContext } from "../Contexts/AuthenticationContext";
import Card from '../Components/Card/Card';
import { useState } from "react";
import PartnerMoodApi from "../PartnerApi/PartnerMoodApi";

const storageKeys = {
    spaceIdKey: 'space-id-key',
    partnerSecretKey: 'partner-secret-key'
}

const AuthenticationProvider = ({ children }) => {
    const [spaceId, setSpaceId] = useState('');
    const [partnerSecret, setPartnerSecret] = useState('');
    const [errorText, setErrorText] = useState('');
    const [loggedIn, setLoggedIn] = useState(false);

    const storedSpaceId = window.localStorage.getItem(storageKeys.spaceIdKey);
    const storedPartnerSecret = window.localStorage.getItem(storageKeys.partnerSecretKey);
    
    const onJoin = async () => {
        const ok = await PartnerMoodApi.login(spaceId, partnerSecret);
        if (!ok) {
            setErrorText('Failed to login');
            return;
        }

        window.localStorage.setItem(storageKeys.spaceIdKey, spaceId);
        window.localStorage.setItem(storageKeys.partnerSecretKey, partnerSecret);
        setLoggedIn(true);
    }

    if (storedSpaceId !== null && storedPartnerSecret !== null) {
        const authenticationContextValue = {
            loggedIn: loggedIn,
            spaceId: storedSpaceId,
            partnerSecret: storedPartnerSecret
        };

        return (
            <AuthenticationContext.Provider value={ authenticationContextValue }>
                { children }
            </AuthenticationContext.Provider>
        )
    }

    if (loggedIn) {
        const authenticationContextValue = {
            loggedIn: loggedIn,
            spaceId: spaceId,
            partnerSecret: partnerSecret
        };

        return (
            <AuthenticationContext.Provider value={ authenticationContextValue }>
                { children }
            </AuthenticationContext.Provider>
        )
    }

    return (
        <>
            <Card header={'Join a space'}>
                <div className='card-input'>
                    <div className='card-input-group'>
                        <label className='card-input-label'>Space ID</label>
                        <input className='card-input-text' value={ spaceId } onChange={ e => setSpaceId(e.target.value) } />
                    </div>
                    <div className='card-input-group'>
                        <label className='card-input-label'>Partner secret</label>
                        <input className='card-input-text' value={ partnerSecret } onChange={ e => setPartnerSecret(e.target.value) } />
                    </div>
                    <div className='card-input-group'>
                        <div className='button button-full-width button-primary' onClick={ onJoin }>
                            Join
                        </div>
                    </div>

                    <div>{ errorText }</div>
                </div>
            </Card>
        </>
    )
}

export default AuthenticationProvider;