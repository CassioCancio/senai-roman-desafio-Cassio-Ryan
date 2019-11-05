import React, { Component, Fragment } from 'react';
import { Text, View, AsyncStorage, Picker, TouchableOpacity } from 'react-native';
import { FlatList } from 'react-native-gesture-handler';

class Main extends Component {

  constructor() {
    super();
    this.state = {
      projetos: [],
      temas: [],
      PickerValueHolder:""
    };
  }

  componentDidMount() {
    this._carregarProjetos();
    this._carregarTemas();
    console.warn(AsyncStorage.getItem('roman-token'));
  }

  _carregarProjetos = async () => {
    try {
      let token = await AsyncStorage.getItem('roman-token');
      console.warn(token);

      await fetch('http://192.168.3.14:5000/api/projetos/'+ this.state.PickerValueHolder, {
        method: 'GET',
        headers: {
          "Content-Type": "application/json",
          "Authorization": 'Bearer ' + token
        },
      })
        .then(resposta => resposta.json())
        .then(data => this.setState({ projetos: data }))
        .catch(erro => console.warn(erro));
    } catch (error) {

    }

  };

  _carregarTemas = async () => {
    try {
      let token = await AsyncStorage.getItem('roman-token');
      console.warn(token);

      await fetch('http://192.168.3.14:5000/api/temas', {
        method: 'GET',
        headers: {
          "Content-Type": "application/json",
          "Authorization": 'Bearer ' + token
        },
      })
        .then(resposta => resposta.json())
        .then(data => this.setState({ temas: data }))
        .catch(erro => console.warn(erro));
    } catch (error) {

    }

  };

  render() {
    return (
      <Fragment>

        <Picker
          selectedValue={this.state.PickerValueHolder}
          onValueChange={(itemValue, itemIndex) => this.setState({ PickerValueHolder: itemValue })} >
          {this.state.temas.map((item, idProjeto) => (
            <Picker.Item label={item.nome} value={item.nome} key={idProjeto} />)
          )}
        </Picker>

        <TouchableOpacity onPress={this._carregarProjetos}>
            <Text>Filtrar</Text>
        </TouchableOpacity>




        <Text></Text>
        <Text>Projetos cadastrados</Text>
        <FlatList
          data={this.state.projetos}
          keyExtractor={item => item.idProjeto}
          renderItem={({ item }) => (
            <View>
              <Text></Text>
              <Text>O professor(a) {item.idUsuarioNavigation.nome} cadastrou o projeto de {item.nome} no tema {item.idTemaNavigation.nome}</Text>
            </View>
          )}
        />
      </Fragment>
    );
  }
}

export default Main;