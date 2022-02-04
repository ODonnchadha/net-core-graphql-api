import React from "react";
import "./App.css";
import { client } from "./ApolloClient/client";
import { ApolloProvider } from '@apollo/client';
import SoftwareDriver from "./Pages/SoftwareDriver";

function App() {
    return (
        <ApolloProvider client={client}>
          <div className="App">
              <SoftwareDriver />
          </div>
        </ApolloProvider>
    );
}

export default App;