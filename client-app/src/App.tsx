import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import { ducks } from './demo';
import DuckItem from './DuckItem';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

function App() {
  const [activities, setActivities] = useState([])

  useEffect(() => {
    axios.get('http://localhost:5000/api/activities').then((response: any) => {
      console.log(response) // just to see what our response is
      setActivities(response.data);
    })
  }, [])

  return (
    <div >
      <Header as='h2' icon='users' content='Reactivities' />
      <List>
        {activities.map((activity: any) => (
            <List.Item key={activity.id}>
                {activity.title} 
            </List.Item>
        ))}
      </List>
    </div>
  );
}

export default App;
