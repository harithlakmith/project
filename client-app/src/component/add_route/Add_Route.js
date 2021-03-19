import logo from './../../logo.svg';
import './Add_Route.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import React from 'react';
import axios from 'axios';



 class Add_Route extends React.Component {

  constructor(props){  
    super(props) 
    this.state = {
      
      RNum:'',
      startAt:'',
      startHoltId:0,
      stopAt:'',
      stopHoltId:0,
      fullTime:0,
      fullPrice:0,
      fullDistance:0

    };
    this.handleChange = this.handleChange.bind(this);
    this.AddRoute = this.AddRoute.bind(this);
  }
  
    handleChange = (e) => {
      this.setState({[e.target.name]:e.target.value});
    }
  
    AddRoute = () => {
      //event.preventDefault();

      axios.post('http://localhost:5000/Route', {
        
       
        /*StartHolt:this.state.startAt,
        StartHoltId:1,
        StopHolt:this.state.stopAt,
        StopHoltId:100,
        Duration:this.state.fullTime,
        Distance:this.state.fullDistance,
        RNum: "this.state.RNum"*/

        StartHoltId: 1,
        StartHolt: this.state.startAt,
        StopHoltId: 10,
        StopHolt: this.state.stopAt,
        Duration: parseInt(this.state.fullTime) ,
        Distance: parseInt(this.state.fullDistance),
        RNum: this.state.RNum
    
    })
      .then(json => {
      
          console.log(json.data);  
        
      });   

    }

    
  
    render() {
      return (
        <div>

<div className="Add_Route" class="">

<div class="Add_Route row m-1">
    <div class="col-md-12">


<div class="mt-5 signup-form">
<form className="form">
    <h2 class="mt-4">Add New Route</h2>
    <p>Please fill in this form to create bus routes!</p>
    <hr/>
    <div class="form-group">
        <div class="row">
            <div class="col"><input type="text" class="form-control" name="RNum" placeholder="RouteNo" onChange={this.handleChange} value={this.state.RNum}  required="required"/></div>
        </div>
    </div>

    <div class="form-group">
        <div class="row">
            <div class="col-6">
              <input type="text" class="form-control" name="startAt" placeholder="Start At" onChange={this.handleChange} value={this.state.startAt} required="required"/></div>
            <div class="col-6">
              <input type="text" class="form-control" name="stopAt" placeholder="Stop At" onChange={this.handleChange} value={this.state.stopAt} required="required"/></div>
        </div>        	
    </div>

    <div class="form-group">
        <div class="row">
            <div class="col-4">
              <input type="text" pattern="[0-9]*" class="form-control" name="fullTime" placeholder="Full Time" onChange={this.handleChange} value={this.state.fullTime} required="required"/></div>
           
            <div class="col-4">
              <input type="text" pattern="[0-9]*" class="form-control" name="fullDistance" placeholder="Full Distance" onChange={this.handleChange} value={this.state.fullDistance} required="required"/></div>
        </div>        	
    </div>
    <hr />

    <div class="form-group">
        <div class="row">
            <div class="col"></div>
        </div> 
        <div class="row">
            <div class="col"></div>
        </div> 
        <div class="row">
            <div class="col"></div>
        </div>        	
    </div>
    
    <div class="form-group">
        <button type="submit" onClick={this.AddRoute} class="btn btn-primary btn-lg">Create</button>
    </div>
</form>
<div class="hint-text">Tiketz <a href="#"><i>Smart Travelling for Smart Lifestyle</i></a></div>
</div>

</div>

</div>
</div>



        </div>
      )
    }
  }
  


export default Add_Route;
