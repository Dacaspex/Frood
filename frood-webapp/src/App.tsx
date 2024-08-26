import "./App.css";
import SpaceContainer from './Pages/SpaceContainer.tsx';
import PartnerMoodApi from "./PartnerApi/PartnerMoodApi.ts";
import AuthenticationProvider from './Providers/AuthenticationProvider.tsx';

PartnerMoodApi.setup();

function App() {
    return (
        <div className="app">
            <div className="container">
                <div className="app-header">Parnter mood</div>

                <AuthenticationProvider>
                    <SpaceContainer />
                </AuthenticationProvider>
            </div>
        </div>
    );
}

export default App;
