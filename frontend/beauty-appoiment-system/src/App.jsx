import "./App.css";
import ServiciosPage from "./pages/servicios/ServiciosPage";

function App() {
  return (
    <div className="app">
      <header className="header">
        <h1>Beauty Appointments</h1>
        <p>Administración de servicios del salón</p>
      </header>

      <main className="main">
        <ServiciosPage />
      </main>
    </div>
  );
}

export default App;
