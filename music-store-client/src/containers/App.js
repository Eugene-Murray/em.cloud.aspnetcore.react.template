import React, { Component } from 'react';
import './App.css';

import { Provider } from 'react-redux';
import { ApolloProvider } from 'react-apollo';
import apolloClient from '../services/apollo';

import Shelf from '../components/shelf/Shelf';
import Header from '../components/Header';
import Footer from '../components/Footer';
import FloatCart from './../components/floatCart/FloatCart';

import store from '../store';


class App extends Component {
  render() {
    return (
      <Provider store={store}>
        <ApolloProvider client={apolloClient}>
        <div className="App">
        <Header />
          <main>
            <Shelf />
          </main>
          <Footer />
          <FloatCart />
        </div>
        </ApolloProvider>
      </Provider>
    )
  }
}

export default App;
