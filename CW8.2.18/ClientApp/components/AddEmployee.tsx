import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';
import { EmployeeData } from './FetchEmployee';
interface AddEmployeeDataState {
    title: string;
    loading: boolean;
    jobList: Array<any>;
    empData: EmployeeData;
}
export class AddEmployee extends React.Component<RouteComponentProps<{}>, AddEmployeeDataState> {
    constructor(props) {
        super(props);
        this.state = { title: "", loading: true, jobList: [], empData: new EmployeeData };
        fetch('api/Employee/GetJobList')
            .then(response => response.json() as Promise<Array<any>>)
            .then(data => {
                this.setState({ jobList: data });
            });
        var empid = this.props.match.params["empid"];
        // This will set state for Edit employee  
        if (empid > 0) {
            fetch('api/Employee/Details/' + empid)
                .then(response => response.json() as Promise<EmployeeData>)
                .then(data => {
                    this.setState({ title: "Edit", loading: false, empData: data });
                });  
        }
        // This will set state for Add employee  
        else {
            this.state = { title: "Create", loading: false, jobList: [], empData: new EmployeeData };
        }
        // This binding is necessary to make "this" work in the callback  
        this.handleSave = this.handleSave.bind(this);
        this.handleCancel = this.handleCancel.bind(this);
    }
    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderCreateForm(this.state.jobList);
        return <div>
            <h1>{this.state.title}</h1>
            <h3>Employee</h3>
            <hr />
            {contents}
        </div>;
    }
    // This will handle the submit form event.  
    private handleSave(event) {
        event.preventDefault();
        const data = new FormData(event.target);
        // PUT request for Edit employee.  
        if (this.state.empData.employeeId) {
            fetch('api/Employee/Edit', {
                method: 'PUT',
                body: data,
            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/fetchemployee");
                })
        }
        // POST request for Add employee.  
        else {
            fetch('api/Employee/Create', {
                method: 'POST',
                body: data,
            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/fetchemployee");
                })
        }
    }
    // This will handle Cancel button click event.  
    private handleCancel(e) {
        e.preventDefault();
        this.props.history.push("/fetchemployee");
    }
    // Returns the HTML Form to the render() method.  
    private renderCreateForm(jobList: Array<any>) {
        return (
            <form onSubmit={this.handleSave} >
                <div className="form-group row" >
                    <input type="hidden" name="employeeId" value={this.state.empData.employeeId} />
                </div>
                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Name">FirstName</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="firstname" defaultValue={this.state.empData.firstname} required />
                    </div>
                </div >
                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Name">LastName</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="lasttname" defaultValue={this.state.empData.lastname} required />
                    </div>
                </div >
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="Department" >Department</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="Department" defaultValue={this.state.empData.department} required />
                    </div>
                </div>
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="Job">Job</label>
                    <div className="col-md-4">
                        <select className="form-control" data-val="true" name="Job" defaultValue={this.state.empData.job} required>
                            <option value="">-- Select Job --</option>
                            {jobList.map(job =>
                                <option key={job.jobId} value={job.jobName}>{job.jobName}</option>
                            )}
                        </select>
                    </div>
                </div >
                <div className="form-group">
                    <button type="submit" className="btn btn-default">Save</button>
                    <button className="btn" onClick={this.handleCancel}>Cancel</button>
                </div >
            </form >
        )
    }
}
