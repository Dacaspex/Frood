import { createContext } from "react";

type AuthenticationContextType = {
    loggedIn: boolean,
    spaceId: string|null,
    partnerSecret: string|null
}

export const AuthenticationContext = createContext<AuthenticationContextType>({ 
    loggedIn: false,
    spaceId: null,
    partnerSecret: null
});