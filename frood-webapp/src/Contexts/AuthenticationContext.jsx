import { createContext } from "react";

export const AuthenticationContext = createContext({ 
    loggedIn: false,
    spaceId: null,
    partnerSecret: null
});