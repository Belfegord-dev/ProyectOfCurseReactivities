//import logo from './logo.svg';
import './App.css';

// Import del curso
import {Component} from 'react';
import axios from 'axios';
//import 'semantic-ui-css/semantic.min.css';
import { Header, Icon, List } from 'semantic-ui-react';

// Metdo nativo de esta version de React
/*function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}*/

//  Método del curso
class App extends Component  {
  state = {
    values: []
  }

  //  Estemétodo se llama inmediatamente luego de cargar el componente
  componentDidMount() {
    //console.log('Contenido de values antes de la peticion axion.get(): ' +this.values);
    //  Se utilza Axios porque es paracido a las promesas en Angular
    axios.get('http://localhost:5000/api/values')
      .then( (response) => {
        //console.log(response);
        this.setState({
          values: response.data
        });
      }).catch(error => {
            console.log('error');
        });
    //console.log(this.values);
  }

  render() {
    return (
      <div>
        <Header as='h2'>
        <Icon name='users' />
        <Header.Content>ProyectOfCurseReactivities</Header.Content>
      </Header>
      <List>
        {this.state.values.map( (value) => (
            <List.Item key = {value.id}>{value.name}</List.Item>
          ) )}
       </List>
      </div>
      

      /*<div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <ul>
            {this.state.values.map( (value: any) => (
              <li key = {value.id}>
                {value.name}
              </li>
             ) )}
          </ul>
        </header>
      </div>*/
    );
  }
  
}

export default App;
