import styles from './SuggestDropdown.less';

import React, { Component } from 'react';
import Autosuggest from 'react-autosuggest';

async function getSuggestionsFromApi(input){
  const result = await fetch('https://localhost:5001/api/suggest/Suggests?input=' + encodeURIComponent(input))
  .then((response) => {
    return response.json();
  })
  .then(data => {
    console.log(data);
    return data;
  }).catch(error => {
    console.log(error);
  });
  return result;
}


async function getSuggestions(value) {

  const inputValue = value.trim().toLowerCase();
  const data = await getSuggestionsFromApi(inputValue);

  return data;
};

const getSuggestionValue = suggestion => suggestion.name;

const renderSuggestion = suggestion => <span>{suggestion.name}</span>;

export default class SuggestDropdown extends Component {
  constructor() {
    super();

    this.state = {
      value: '',
      suggestions: [],
      isLoading: false
    };
    
    this.lastRequestId = null;
  }

  loadSuggestions(value) {
    // Cancel the previous request
    if (this.lastRequestId !== null) {
      clearTimeout(this.lastRequestId);
    }
    
    this.setState({
      isLoading: true
    });
    
    // Fake request
    this.lastRequestId = setTimeout(() => {

      getSuggestions(value);
      setTimeout(() => {
        getSuggestions(value)
        .then((data) => {

          let dataArr = [];

          const arr = data.slice();
          for (const child of arr) {
            console.log(child);
            dataArr.push({
              name: child
            })
          }

          console.log(data);
          console.log(dataArr);
          this.setState({
            isLoading: false,
            suggestions: dataArr
          });
        })
      }, 1000);
    }, 10);
  }

  onChange = (event, { newValue }) => {
    this.setState({
      value: newValue
    });
  };

  onSuggestionsFetchRequested = ({ value }) => {
    this.loadSuggestions(value);
  };

  onSuggestionsClearRequested = () => {
    this.setState({
      suggestions: []
    });
  };

  render() {
    const { value, suggestions, isLoading } = this.state;
    const inputProps = {
      placeholder: "Писать тут",
      value,
      onChange: this.onChange
    };
    const status = (isLoading ? 'Loading...' : 'Начните писать для загрузки');

    return (
      <div id="SuggestDropdown" className={styles.container}>
        <div className={styles.textContainer}>
          <div className={styles.title}>SuggestDropdown</div>
        </div>
        <div className="status">
          <strong>Статус:</strong> {status}
        </div>
        <div className={styles.autosuggest}>
          <Autosuggest
            suggestions={suggestions}
            onSuggestionsFetchRequested={this.onSuggestionsFetchRequested}
            onSuggestionsClearRequested={this.onSuggestionsClearRequested}
            getSuggestionValue={getSuggestionValue}
            renderSuggestion={renderSuggestion}
            inputProps={inputProps}
          />
        </div>
      </div>
    );
  }
}
