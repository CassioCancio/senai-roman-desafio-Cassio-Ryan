import {Route, Link, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom';
import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';
import Projetos from '../src/pages/Projetos/Projetos';

const RotaPrivada = ({component: Component}) =>(
    <Route
        render={props =>
            localStorage.getItem("usuario-roman") !== null ? (
                <Component {...props} /> 
            ) : (
                <Redirect 
                    to={{ pathname: "/login", state: {from: props.location}}}
                />
            )
        }
        
    />    
      
);
const routing = (
    <Router>
        <div>
            <Switch>
                <Route exact path='/' component={App} />
                <RotaPrivada path='/projetos' component={Projetos}/>
                
            </Switch>
        </div>
    </Router>
)

ReactDOM.render(<App />, document.getElementById('root'));


serviceWorker.unregister();
