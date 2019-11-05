import React,{Component} from 'react';


import Axios from 'axios';

import {Link} from 'react-router-dom';






export default class Projetos extends Component{

    constructor(){
        super();
        this.state = {
            permissao: "",
            lista: [],
           
            
        };
    }

    componentDidMount(){
        this.listaAtualizada();
    }
    
    listaAtualizada =() =>{
        Axios.get('http://192.168.3.14:5000/api/projetos',{
            headers:{ Authorization: 'Bearer ' + localStorage.getItem('usuario-roman')}
        }
        )
        .then(response => {
            this.setState({lista: response.data})
            console.log(this.state)
        })
    }
   

    adicionaItem =(event) => {
        event.preventDefault();
        console.log(this.state.nome);
        fetch('http://192.168.3.14:5000/api/projetos',{
            method: 'POST',
            body: JSON.stringify({nome: this.state.nome}),
            headers: {
                "Content-Type": "application/json"
            }
        })
        .then(this.listaAtualizada())
        .catch(error => console.log(error))

    }

    render(){
        return(
           <div>
                
       
                   <section id="lancamentos">
                       
                        {this.state.lista.map(element =>{
                            return(
                                
                                <div className="filmes_lancamento" >
                                    <div className="filmes_nome" >
                                        <p>{element.nome}</p>
                                    </div>
                                </div>
                            )
                        })}
                        
                   </section>
           </div>
        );
    }
}

// export default Eventos;