import { Version, Environment, EnvironmentType } from '@microsoft/sp-core-library';
import {
  BaseClientSideWebPart,
  IPropertyPaneConfiguration,
  PropertyPaneTextField
} from '@microsoft/sp-webpart-base';
import { escape } from '@microsoft/sp-lodash-subset';

import styles from './LatestUpdatesWebPart.module.scss';
import * as strings from 'LatestUpdatesWebPartStrings';
import{SPComponentLoader}from '@microsoft/sp-loader';
import * as $ from 'jquery';
require('bootstrap');

//require('jquery-scroller');
export interface ILatestUpdatesWebPartProps {
  description: string;
}

export default class LatestUpdatesWebPart extends BaseClientSideWebPart<ILatestUpdatesWebPartProps> {

  public render(): void {
    let url="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css";
    SPComponentLoader.loadCss(url);
    this.domElement.innerHTML = `
      <div class="${styles.latestUpdates}">
      
        <div class="${styles.container}">
        <div>
        <label class="btn-primary col-sm-2" style="padding:0px">Latest Updates</label>
        <marquee behavior="scroll" direction="left" id="marqueescroll" class="col-sm-10" style="border: 1px solid black;">
        </marquee>
        </div>
        </div>
      </div>
      `;
      this.GetUpdates();
      $(document).ready(function () {
       
      });
  }
  private GetUpdates()
  {
    if (Environment.type === EnvironmentType.Local)   //Checking Environment
    {
      this.domElement.querySelector('#marqueescroll').innerHTML = "Sorry this does not work in local workbench";
    }
    else
    {
      var call = $.ajax({
        url: this.context.pageContext.web.absoluteUrl+`/_api/web/Lists/getByTitle('SpfxLatestUpdates')/Items?$select=UpdateDescription`,
        type:"GET",
          dataType: "json",
          headers: {
              Accept: "application/json;odata=verbose"
          }
      });
      call.done(function (data, textStatus, jqXHR) {
        var Updates = $("#marqueescroll");
        $.each(data.d.results, function (index, value) {       
          Updates.append(`<p style="margin:0;padding:0;margin-left:20px;display:inline-block;vertical-align:top;">${value.UpdateDescription}</p>`);
        });
      });
      call.fail(function (jqXHR, textStatus, errorThrown) {
        var response = JSON.parse(jqXHR.responseText);
        var message = response ? response.error.message.value : textStatus;
        alert("Call failed. Error: " + message);
      });
    }
  }
  protected get dataVersion(): Version {
    return Version.parse('1.0');
  }
  protected getPropertyPaneConfiguration(): IPropertyPaneConfiguration {
    return {
      pages: [
        {
          header: {
            description: strings.PropertyPaneDescription
          },
          groups: [
            {
              groupName: strings.BasicGroupName,
              groupFields: [
                PropertyPaneTextField('description', {
                  label: strings.DescriptionFieldLabel
                })
              ]
            }
          ]
        }
      ]
    };
  }
}
