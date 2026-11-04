import { customElement } from '@umbraco-cms/backoffice/external/lit';
import { SpeedwarePickerBaseElement } from '../speedware-picker.element.js';
import { ImadeSpeedwareWebService } from '../../api/index.js';
import type { PickerItem } from '../types.js';

@customElement('imade-speedware-publishing-types-picker')
export class PublishingTypesPickerElement extends SpeedwarePickerBaseElement {
	protected readonly localizationKey = 'speedwarePublishingTypesPicker';

	protected async fetchItems(): Promise<PickerItem[]> {
		const { data } = await ImadeSpeedwareWebService.getPublishingTypes({ throwOnError: true });
		return data.map((t) => ({ id: t.id, label: t.name }));
	}
}

export default PublishingTypesPickerElement;

declare global {
	interface HTMLElementTagNameMap {
		'imade-speedware-publishing-types-picker': PublishingTypesPickerElement;
	}
}
