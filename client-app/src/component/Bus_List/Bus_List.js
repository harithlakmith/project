
import React, {Component} from 'react'
import queryString, { parse } from 'query-string';
import axios from 'axios'
import './Bus_List.css';
import { RouteComponentProps, BrowserRouter, Switch, Route, Link, useLocation, useRouteMatch, useParams} from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.min.css';
import { RichText, Date } from 'prismic-reactjs';
import Moment from 'moment';


class Bus_List extends Component {


  
    state = {
       buses: [],
       product: '',
        dateYMD:''
      };
    
      
   componentDidMount() {
    axios.get('http://localhost:5000/Search/SearchTicket?date=2021-01-28&from_=Aluthgama&to_=Galle')
    .then(res => {
      console.log(res);
      this.setState({
        buses: res.data
      });
    })
    }

      render(){


        const { buses } = this.state
      
        const buslist = buses.length ? (
          buses.map(bus => {
         
            return (
                <div class="card  bg-light mb-3">
                        <div class="card-header">
                            <div class="row">
                            
                                <div class="col-md-6"><h3>{bus.RNum}&nbsp;&nbsp; {bus.RouteStartHolt} - {bus.RouteStopHolt}</h3></div>
                                <div class="col-md-6"><h3>{Moment(bus.Date).format('YYYY-MM-DD')}</h3></div>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-3"><p>From: {bus.FromHolt} To: {bus.ToHolt}</p><p>Time Duration:{bus.Duration} hours</p></div>
                                <div class="col-md-3"><p>Arriving Time:{Moment(bus.ArrivedTime).format('hh:mm A')}</p></div>
                                <div class="col-md-3"><p>Price:Rs {bus.TicketPrice} /=</p>
                                    
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <a href="/Book_Now" class="btn btn-primary btn-lg btn-block">BOOK NOW</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>  
            )
          })
        ) : (
          <div className="center">No Buses available</div>
        );


        return (
    
            <div class=" box4">
                <div class="row">
                    <div class="col-12">
                    <h2>TICKETS RESERVATION SOLUTION</h2>
                    </div>
               
                </div>
                <div class="row">
                    <div class="col-12">
                 
                   {buslist}
                    
                    </div>
                </div>
            </div>
  );
      }

  
}

export default Bus_List;
