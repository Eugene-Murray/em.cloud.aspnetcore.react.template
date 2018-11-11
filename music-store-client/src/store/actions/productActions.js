import { FETCH_PRODUCTS } from './types';
import axios from 'axios';
import gql from 'graphql-tag';
import { apollo } from 'react-apollo';


const productsAPI = "http://localhost:8001/api/products";
//const productsAPI = "http://localhost:60755";

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

//   const getTickets = gql`
//   query query {
//   	musicTickets {
//       id
// 			description
//       title
//     }
// }
// `;


fetch('http://localhost:60755', {
  method: 'POST',
  headers: {
    'Content-Type': 'application/json',
    'Accept': 'application/json',
  },
  body: JSON.stringify({query: `{
  	musicTickets {
      id
			description
      title
    }
}`})
})
  .then(r => r.json())
  .then(data => console.log('data returned:', data));

// const getUserQueryOptions = {
  
  
//   props: ({
//     ownProps,
//     get: { loading, getUser, getRole, refetch },
//   }) => {
//     return {
      
//       refetchUser: refetch,
//     };
//   },
// };
  
//apollo(getTickets);
  
  axios.get(productsAPI)
    .then(res => {
      let { products } = res.data;

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