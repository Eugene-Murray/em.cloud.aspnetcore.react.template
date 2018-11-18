import { FETCH_PRODUCTS } from './types';
import axios from 'axios';
import gql from 'graphql-tag';
import { apollo } from 'react-apollo';
import ApolloClient from 'apollo-boost';


const productsAPI = "http://localhost:8001/api/products";
//const productsAPI = "https://localhost:44319/graphql";

const client = new ApolloClient({
  uri: 'https://localhost:44319/graphql'
});

const compare = {
  'lowestprice': (a, b) => {
    if (a.price < b.price)
      return -1;
    if (a.price > b.price)
      return 1;
    return 0;
  },
  'highestprice': (a, b) => {
    if (a.price > b.price)
      return -1;
    if (a.price < b.price)
      return 1;
    return 0;
  }
}

export const fetchProducts = (filters, sortBy, callback) => dispatch => {

  client.query({
    query: gql`
    query {
      musicTickets {
        id
        sku
        title
        description
        venuSize
        isFreeShipping
        currencyId
        currencyFormat
        price
      }
    }
    `,
  })
  .then(data => {
    console.warn(data.data.musicTickets);
    let { products } = data.data.musicTickets;
    console.warn(products);

    if(!!filters && filters.length > 0){
      products = products.filter( p => filters.find( f => p.venuSize.find( size => size === f ) ) )
    }

    if(!!sortBy){
      products = products.sort(compare[sortBy]);
    }

    if(!!callback) {
      callback();
    }

    // return dispatch({
    //   type: FETCH_PRODUCTS,
    //   payload: products
    // });

  })
  .catch(err => {
    console.log(err);
    throw new Error('Could not fetch products. Try again later.');
  });


  axios.get(productsAPI)
    .then(res => {
      let { products } = res.data;

      console.warn(products);

      if(!!filters && filters.length > 0){
        products = products.filter( p => filters.find( f => p.availableSizes.find( size => size === f ) ) )
      }

      if(!!sortBy){
        products = products.sort(compare[sortBy]);
      }

      if(!!callback) {
        callback();
      }

      return dispatch({
        type: FETCH_PRODUCTS,
        payload: products
      });

    })
    .catch(err => {
      console.log(err);
      throw new Error('Could not fetch products. Try again later.');
    });
}


// fetch('https://localhost:44319/graphql', {
//   method: 'POST',
//   headers: {
//     'Content-Type': 'application/json',
//     'Accept': 'application/json',
//   },
//   body: JSON.stringify({query: `{
//   	musicTickets {
//       id
//       sku
//       title
// 			description
//       venuSize
//       price
//     }
// }`})
// })
//   .then(r => r.json())
//   .then(data => console.log('data returned:', data));