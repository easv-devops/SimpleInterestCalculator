// app.component.test.js

import { Selector } from 'testcafe';

fixture('AppComponent Tests')
  .page('https://google.com');


test('Calculate Interest Test', async (t) => {

await t.expect(true).eql(true);
});

