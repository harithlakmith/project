import React, { Component } from 'react'
//import './welcome-text/welcome_text.css';
//import './css/datepicker.css';
//import './css/bootstrap.min.css';
import './css/tooplate-style.css';
import './Find_Bus.css';
import 'bootstrap/dist/css/bootstrap.min.css';
//import welcome_text from './welcome-text/welcome_text';
import axios from 'axios'

 class Find_Bus extends Component {
    state = {
        towns: []
      }
    componentDidMount(){
        axios.get('http://localhost:5000/RouteInfo/townlist')
          .then(res => {
            console.log(res);
            this.setState({
              towns: res.data
            });
          })
      }
    render() {
        const { towns } = this.state
        const townList = towns.length ? (
          towns.map(town => {
            return (
                <option value={town.HoltName}>{town.HoltName}</option>
            )
          })
        ) : (
          <div className="center">No Towns available</div>
        );

        return (
        <div>
        <div class="tm-main-content">
        <div class="tm-section tm-bg-img" id="tm-section-1">
    
        <div class="tm-bg-white ie-container-width-fix-2">
            <div class="container ie-h-align-center-fix">
                <div class="row">
                    <div class="col-xs-12 ml-auto mr-auto ie-container-width-fix">

                        <form action="/bus-list/:id" method="get" class="tm-search-form tm-section-pad-2">
                            <div class="form-row tm-search-form-row">
                                <div class="form-group tm-form-element tm-form-element-50">
                                <select name="from" class="form-control tm-select" id="from">
                                        <option value="">From ...</option>
                                        {townList}
                                    </select>
                                    </div>
                                <div class="form-group tm-form-element tm-form-element-50">
                                <select name="to" class="form-control tm-select" id="to">
                                        <option value="">To ...</option>
                                        {townList}
                                    </select>
                                </div>
                                <div class="form-group tm-form-element tm-form-element-50">
                                    <i class="fa fa-calendar fa-2x tm-form-element-icon"></i>
                                    <input name="date" type="date" class="form-control" id="inputCheckOut" placeholder="Date ..."/>
                                </div>
                            </div>
                            <div class="form-row tm-search-form-row">
                                <div class="form-group tm-form-element tm-form-element-2">
                                    <button type="submit" class="btn btn-primary tm-btn-search">Check Availability</button>
                                    
                                </div>
                                

                              </div>
                              <div class="form-row tm-fx-col-xs">
                                  <p class="pr-5 pl-2 tm-margin-b-0"><h3><br/><br/><marquee><b class="wel">WELCOME TO TICKETZ&nbsp;&nbsp;</b>Find your bus and reserve your seat!</marquee></h3></p>
                                  <a href="#" class="ie-10-ml-auto ml-5 pl-5 mt-1 tm-font-semibold tm-color-primary"><img src="./logo.png" height="100" alt="CoolBrand"/></a>
                              </div>
                        </form>
                    </div>                        
                </div>      
            </div>
        </div>                  
    </div>

    
    </div> 




    </div>  

        )
    }
}


export default Find_Bus