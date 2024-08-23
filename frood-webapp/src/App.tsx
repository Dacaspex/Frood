import "./App.css";
import SpaceContainer from './Pages/SpaceContainer.tsx';
import AuthenticationProvider from './Providers/AuthenticationProvider.tsx';

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
